using CibDemo.Models;
using Microsoft.ApplicationInsights;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CibDemo.Controllers
{
    public class PiController : ApiController
    {
        private static int Invocations { get; set; }
        

        // GET api/values/5
        public Object Get(int id)
        {
            Invocations++;
            Trace.TraceInformation("Otro cliente al que atender.");
            if (id < 10)
            {   var ex = new ArgumentException("Requerida una precisión superior a 10.");

                // Telemetría para App Insights
                var telemetry = new TelemetryClient();
                var telemetryInfo = new Dictionary<string, string>
                { { "invocaciones", Convert.ToString(Invocations) } };
                var telemetryMeasurements = new Dictionary<string, double>
                { { "digitos", id } };
                telemetry.TrackException(ex, telemetryInfo, telemetryMeasurements);

                // Mensaje para Applications Logs
                Trace.TraceError("El cliente anda despistado.");

                throw ex;
            }
            BigNumber x = new BigNumber(id);
            BigNumber y = new BigNumber(id);
            x.ArcTan(16, 5);
            y.ArcTan(4, 239);
            x.Subtract(y);
            
            string pi = x.AsPrintableString();

            if (pi.Length > 1000)
            {
                Trace.TraceWarning("Resultado de " + pi.Length + " caracteres!");
            }

            var resultado = new
            {
                pi = pi,
                invocations = Invocations
            };

            return resultado;
        }

 
    }
}
