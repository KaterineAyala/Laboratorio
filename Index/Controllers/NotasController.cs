using Index.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Index.Controllers
{
    public class NotasController : Controller
    {
        // GET: Notas

        public ActionResult Index()
        {
            using (EstudianteEntities bd = new EstudianteEntities())
            {

                var ListadoEstudiante = bd.Tbl_NotasEstudiante.ToList();


                return View(ListadoEstudiante);
            }
        }

        public ActionResult Save(String nombre, String lab1, String lab2, String lab3, String par1, String par2, String par3)
        {
            using (EstudianteEntities bd = new EstudianteEntities())
            {
                Tbl_NotasEstudiante est = new Tbl_NotasEstudiante();

                est.Nombre = nombre;
                est.Laboratorio1 = Convert.ToDecimal(lab1);
                est.Parcial1 = Convert.ToDecimal(par1);
                est.Laboratorio2 = Convert.ToDecimal(lab2);
                est.Parcial2 = Convert.ToDecimal(par2);
                est.Laboratorio3 = Convert.ToDecimal(lab3);
                est.Parcial3 = Convert.ToDecimal(par3);


                bd.Tbl_NotasEstudiante.Add(est);
                bd.SaveChanges();

                return Redirect("/Notas/Resultado");
            }
        }

        public ActionResult procesar(String nombre, String lab1, String lab2, String lab3, String par1, String par2, String par3)
        {
            if (nombre.Equals("") && lab1.Equals("") && lab2.Equals("") && lab3.Equals("") && par1.Equals("") && par2.Equals("") && par3.Equals(""))

                ViewBag.total = nombre;
            ViewBag.total = lab1;
            ViewBag.total = lab2;
            ViewBag.total = lab3;
            ViewBag.total = par1;
            ViewBag.total = par2;
            ViewBag.total = par3;

            return Redirect("/Notas/Estudiante");

            return Redirect("/Notas/Resultado");

            return Redirect("/Notas/Index");
        }
        public ActionResult Resultado(String nombre, String lab1, String par1, String lab2, String par2, String lab3, String par3)
        {

            //int lab = Convert.ToInt32(lab1);

            ViewBag.nombre = nombre;
            ViewBag.lab1 = lab1;
            ViewBag.par1 = par1;
            ViewBag.lab1 = lab2;
            ViewBag.par2 = par2;
            ViewBag.lab1 = lab3;
            ViewBag.par3 = par3;

            float porcentajeperiodo1 = ((float)(float.Parse(lab1) * 0.40) + (float)((float.Parse(par1)) * 0.60)) / 3;
            ViewBag.total1 = porcentajeperiodo1;
            float porcentajeperiodo2 = ((float)(float.Parse(lab2) * 0.40) + (float)((float.Parse(par2)) * 0.60)) / 3;
            ViewBag.total2 = porcentajeperiodo2;
            float porcentajeperiodo3 = ((float)(float.Parse(lab3) * 0.40) + (float)((float.Parse(par3)) * 0.60)) / 3;
            ViewBag.total3 = porcentajeperiodo3;


            float NotaGlobal = (porcentajeperiodo1 + porcentajeperiodo2 + porcentajeperiodo3);
            ViewBag.total = NotaGlobal;

            return View();
        }

        public ActionResult Registro()
        {
            String nombre = " ";
            ViewBag.EnviandoDatosAEstudiante = nombre;
            return View();
        }

        public ActionResult Delete(int id)
        {
            using (EstudianteEntities bd = new EstudianteEntities())
            {

                Tbl_NotasEstudiante eliminardatos = bd.Tbl_NotasEstudiante.Where(x => x.id_estudiante == id).FirstOrDefault();

                bd.Tbl_NotasEstudiante.Remove(eliminardatos);
                bd.SaveChanges();


                return View("/Notas/Estudiante");
            }
        }
    }
}