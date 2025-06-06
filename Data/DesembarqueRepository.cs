using System;
using System.Collections.Generic;
using System.Linq;
using Masterdata.Models;

namespace Masterdata.Data
{
    public static class DesembarqueRepository
    {
        private static List<Desembarque> _data = new List<Desembarque>();

        static DesembarqueRepository()
        {
            // Simulated data
            for (int i = 1; i <= 200; i++)
            {
                _data.Add(new Desembarque
                {
                    Id = i,
                    FechaGrabacion = DateTime.Today.AddDays(-i),
                    Referencia = $"REF-{i:000}",
                    Revisado = i % 2 == 0
                });
            }
        }

        public static IEnumerable<Desembarque> GetAll()
        {
            return _data.OrderBy(d => d.Id);
        }
    }
}
