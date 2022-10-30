using AdminEmpl.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminEmpl.Servicios
{
    public interface IEmpleadoRepo
    {
            IEnumerable<Empleado> BuscEmpl(string termBusq);//Obtenemos todos los empleados
            IEnumerable<Empleado> ObtTodosEmpleados();//Obtenemos todos los empleados
            Empleado ObtEmpleado(int id);//Obtenemos a un empleado a través del id
            Empleado EditEmpleado(Empleado EditEmpleado);
            Empleado AgregEmpleado(Empleado AgregEmpleado);
            Empleado BorrEmpleado(int id);
            //IEnumerable<DepartCabCont> ContDepatEmpl();
            IEnumerable<DepartCabCont> ContDepatEmpl(Departamento? depart);
    }
}
