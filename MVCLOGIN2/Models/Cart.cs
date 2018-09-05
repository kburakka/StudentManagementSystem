using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.Mvc;
using MVCLOGIN2.Models;

namespace MVCLOGIN2.Models
{
    public class Cart
    {
        private sisEntities1 db = new sisEntities1();
        private List<CartLine> _cardLines = new List<CartLine>();
        public List<CartLine> CartLines
        {
            get { return _cardLines; }
        }
        public void AddCourse(cours cours, int quantity)
        {
            var line = _cardLines.FirstOrDefault(i => i.cours.courseID == cours.courseID);
            if (line == null)
            {
                _cardLines.Add(new CartLine() { cours = cours, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }

        }
   
        public void DeleteCourse(cours cours)
        {
            _cardLines.RemoveAll(i => i.cours.courseID == cours.courseID);

        }

        public double Total()
        {
            return _cardLines.Sum(i => i.cours.ects * i.Quantity);
        }

        public void Clear()
        {
            _cardLines.Clear();
        }


        public class CartLine
        {
            public cours cours { get; set; }
            public int Quantity { get; set; }

        }
    }
}
