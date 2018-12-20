using System;
using System.Collections.Generic;
using System.Text;
using Hl7.Fhir.Model;

namespace Jembi.Core.Interfaces
{
    public interface IObservationService
    {
        Observation Create(string code, decimal value);

        Observation GetObservationById(string id);

        IEnumerable<Observation> GetVitalSignByCode(string code);

        IEnumerable<Observation> GetVitalSignByPatient(string patientId);

        IEnumerable<Observation> GetVitalSignByPatientAndCode(string patientId, string code);

        IEnumerable<Observation> GetVitalSignByPatientAndDate(string patientId, string date);
    }
}
