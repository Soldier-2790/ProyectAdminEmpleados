using AdminEmpl.Modelos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdminEmpl.Servicios
{
    public class SQLEmpleadoRepo : IEmpleadoRepo
    {
        private readonly AppDbContext contexto;

        public SQLEmpleadoRepo(AppDbContext contexto)
        {
            this.contexto = contexto;
        }
        /*
        public Empleado AgregEmpleado(Empleado AgregEmpleado)
        {
            contexto.Empleados.Add(AgregEmpleado);
            contexto.SaveChanges();
            return AgregEmpleado;
        }
        */
        public Empleado AgregEmpleado(Empleado AgregEmpleado)
        {
            contexto.Database.ExecuteSqlRaw("spAgrEmpl {0}, {1}, {2}, {3}", AgregEmpleado.Nombre, AgregEmpleado.CorreoE, AgregEmpleado.FotoDir, AgregEmpleado.Depart);
            return AgregEmpleado;
        }
        public Empleado BorrEmpleado(int id)
        {
            Empleado empleado = contexto.Empleados.Find(id);
            if (empleado != null)
            {
                contexto.Empleados.Remove(empleado);
                contexto.SaveChanges();
            }
            return empleado;
        }

        public IEnumerable<Empleado> BuscEmpl(string termBusq)
        {
            if (string.IsNullOrEmpty(termBusq))
            {
                return contexto.Empleados;
            }
            return contexto.Empleados.Where(e => e.Nombre.Contains(termBusq) || e.CorreoE.Contains(termBusq));
        }

        public IEnumerable<DepartCabCont> ContDepatEmpl(Departamento? depart)
        {
            IEnumerable<Empleado> consult = contexto.Empleados;
            if (depart.HasValue)
            {
                consult = consult.Where(e => e.Depart == depart.Value);
            }
            return consult.GroupBy(e => e.Depart)
                .Select(g => new DepartCabCont()
                {
                    Departamento = g.Key.Value,
                    Contador = g.Count()
                }).ToList();
        }

        public Empleado EditEmpleado(Empleado EditEmpleado)
        {
            var empleado = contexto.Empleados.Attach(EditEmpleado);
            empleado.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            contexto.SaveChanges();
            return EditEmpleado;
        }
        /*
        public Empleado ObtEmpleado(int id)
        {
            return contexto.Empleados.Find(id);
        }
        */
        /*
        public Empleado ObtEmpleado(int id)
        {
            return contexto.Empleados
                .FromSqlRaw<Empleado>("spObtEmplPorId {0}",id).ToList().FirstOrDefault();
        }
        */
        public Empleado ObtEmpleado(int id)
        {
            SqlParameter param = new SqlParameter("@Id", id);
            return contexto.Empleados
                .FromSqlRaw<Empleado>("spObtEmplPorId @Id", param).ToList().FirstOrDefault();
        }
        /*
        public IEnumerable<Empleado> ObtTodosEmpleados()
        {
            return contexto.Empleados;
        }
        */
        public IEnumerable<Empleado> ObtTodosEmpleados()
        {
            return contexto.Empleados.FromSqlRaw<Empleado>("Select * From Empleados").ToList();
        }
        //Para añadir un proceso almacenado haremos lo siguiente:
        //En la consola debemos poner lo siguiente Add-Migration [NombProcAlm]
        //Quedando Add-Migration spObtEmplPorId
        //Luego de que cree las clases debemos poner el proceso
        //Ya habiendo declarado debemos poner el comando Update-Database
    }
}
