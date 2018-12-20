using Hl7.Fhir.Rest;
using Jembi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Hl7.Fhir.Model;

namespace Jembi.Core.Services
{
    public class ObservationService : IObservationService
    {
        private IObservationManager _observationManager;

        public ObservationService(IObservationManager observationManager)
        {
            _observationManager = observationManager;
        }

        public Observation Create(string code, decimal value)
        {
            var observation = _observationManager.Create(code, value);

            return observation;
        }

        public IEnumerable<Observation> GetVitalSignByCode(string code)
        {
            var observation = _observationManager.GetVitalSignByCode(code);

            return observation;
        }

        public IEnumerable<Observation> GetVitalSignByPatient(string patientId)
        {
            var observation = _observationManager.GetVitalSignByPatient(patientId);

            return observation;
        }

        public IEnumerable<Observation> GetVitalSignByPatientAndCode(string patientId, string code)
        {
            var observation = _observationManager.GetVitalSignByPatientAndCode(patientId, code);

            return observation;
        }

        public IEnumerable<Observation> GetVitalSignByPatientAndDate(string patientId, string date)
        {
            var observation = _observationManager.GetVitalSignByPatientAndDate(patientId, date);

            return observation;
        }

        public Observation GetObservationById(string observationId)
        {
            var observation = _observationManager.GetObservationById(observationId);

            return observation;
        }
    }
}
