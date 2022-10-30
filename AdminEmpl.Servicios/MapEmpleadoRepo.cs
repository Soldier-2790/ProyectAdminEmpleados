using AdminEmpl.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdminEmpl.Servicios
{
    public class MapEmpleadoRepo : IEmpleadoRepo
    {
        private List<Empleado> _empleadoLista;
        public MapEmpleadoRepo()
        {
            _empleadoLista = new List<Empleado>()
            {
                new Empleado() {Id = 1, Nombre = "Mary", Depart = Departamento.RH, CorreoE = "mary@pragimtech.com", FotoDir="mary.jpg"},
                new Empleado() {Id = 2, Nombre = "John", Depart = Departamento.TI, CorreoE = "john@pragimtech.com", FotoDir="john.jpg"},
                new Empleado() {Id = 3, Nombre = "Sara", Depart = Departamento.TI, CorreoE = "sara@pragimtech.com", FotoDir="sara.jpg"},
                new Empleado() {Id = 4, Nombre = "David", Depart = Departamento.Contabilidad, CorreoE = "david@pragimtech.com", },
                new Empleado() {Id = 5, Nombre = "Carl", Depart = Departamento.Ninguno, CorreoE = "carl@pragimtech.com", FotoDir ="carl.png"},
                new Empleado() {Id = 6, Nombre = "Park", Depart = Departamento.Ninguno, CorreoE = "park@pragimtech.com", FotoDir="park.jpg"},
                new Empleado() {Id = 7, Nombre = "Paty", Depart = Departamento.RH, CorreoE = "paty@pragimtech.com", FotoDir="paty.jpg"},
                new Empleado() {Id = 8, Nombre = "Gen", Depart = Departamento.TI, CorreoE = "gen@pragimtech.com",},
                new Empleado() {Id = 9, Nombre = "Lan", Depart = Departamento.TI, CorreoE = "lan@pragimtech.com",},
            };
        }
        public IEnumerable<Empleado> ObtTodosEmpleados()
        {
            return _empleadoLista;
        }
        public Empleado ObtEmpleado(int id)
        {
            return _empleadoLista.FirstOrDefault(e => e.Id == id);
        }

        public Empleado EditEmpleado(Empleado EditEmpleado)
        {
            Empleado empleado = _empleadoLista.FirstOrDefault(e => e.Id == EditEmpleado.Id);
            if (empleado != null)
            {
                empleado.Nombre = EditEmpleado.Nombre;
                empleado.CorreoE = EditEmpleado.CorreoE;
                empleado.Depart = EditEmpleado.Depart;
                empleado.FotoDir = EditEmpleado.FotoDir;
            }
            return empleado;
        }

        public Empleado AgregEmpleado(Empleado AgregEmpleado)
        {
            AgregEmpleado.Id = _empleadoLista.Max(e => e.Id) + 1;
            _empleadoLista.Add(AgregEmpleado);
            return AgregEmpleado;
        }

        public Empleado BorrEmpleado(int id)
        {
            Empleado empleadoBorr = _empleadoLista.FirstOrDefault(e => e.Id == id);
            if (empleadoBorr != null)
            {
                _empleadoLista.Remove(empleadoBorr);
            }
            return empleadoBorr;
        }
        /*
        public IEnumerable<DepartCabCont> ContDepatEmpl()
        {
            return _empleadoLista.GroupBy(e => e.Depart)
                .Select(g => new DepartCabCont()
                {
                    Departamento = g.Key.Value,
                    Contador = g.Count()
                }).ToList();
        }
        */
        public IEnumerable<DepartCabCont> ContDepatEmpl(Departamento? depart)
        {
            IEnumerable<Empleado> consult = _empleadoLista;
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

        public IEnumerable<Empleado> BuscEmpl(string termBusq)
        {
            if (string.IsNullOrEmpty(termBusq))
            {
                return _empleadoLista;
            }
            return _empleadoLista.Where(e => e.Nombre.Contains(termBusq) || e.CorreoE.Contains(termBusq));
        }
    }
}
