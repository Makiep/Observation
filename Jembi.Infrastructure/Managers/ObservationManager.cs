using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Jembi.Core.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jembi.Infrastructure.Managers
{
    public class ObservationManager: IObservationManager
    {
        private FhirClient _client;
        public string _testEndpoint = "http://fhirtest.uhn.ca/baseDstu2";

        public ObservationManager()
        {
            _client = new FhirClient(new Uri(_testEndpoint));
        }

        public Observation Create(string code, decimal value)
        {
            var systemUri = new Uri("http://unitofmeasure.org");

            var observation = new Observation();
            observation.Status = Observation.ObservationStatus.Preliminary;
            observation.Code = new CodeableConcept("http://loinc.org", code);
            observation.Value = new Quantity() { System = systemUri.ToString(), Value = value, Code = "mg", Unit = "miligram" };
            observation.BodySite = new CodeableConcept("http://snomed.info/sct", "182756003");

            var entry = _client.Create(observation);
            return entry;
        }

        public Observation GetObservationById(string observationId)
        {
            var searchParameters = new SearchParams();
            searchParameters.Add("", observationId);
            var result = _client.Search(searchParameters, ResourceType.Observation.ToString());
            var ob = result.Entry.Select(s => (Observation)s.Resource);

            return null;
        }

        public void GetObservationById2(string patientId)
        {
            var client = new RestClient("http://fhirtest.uhn.ca/baseDstu2/Observation?_patient=456");

            var request = new RestRequest("resource", Method.GET);
            client.Execute(request);

        }

        public IEnumerable<Observation> GetVitalSignByPatient(string patientId)
        {
            var searchParameters = new SearchParams();
            searchParameters.Add("_patient", patientId);
            searchParameters.Add("category", "vital-signs");
            var result = _client.Search(searchParameters, ResourceType.Observation.ToString());
            var observations = result.Entry.Select(s => (Observation)s.Resource).ToList();

            return observations;
        }

        public IEnumerable<Observation> GetVitalSignByPatientAndCode(string patientId, string code)
        {

            var searchParameters = new SearchParams();
            searchParameters.Add("_patient", patientId);
            searchParameters.Add("_code", code);
            var result = _client.Search(searchParameters, ResourceType.Observation.ToString());
            var observations = result.Entry.Select(s => (Observation)s.Resource).ToList();

            return observations;
        }

        public IEnumerable<Observation> GetVitalSignByPatientAndDate(string patientId, string date)
        {
            var searchParameters = new SearchParams();
            searchParameters.Add("_lastUpdated", "gt" + date);
            searchParameters.Add("_patient", patientId);
            var result = _client.Search(searchParameters, ResourceType.Observation.ToString());
            var observations = result.Entry.Select(s => (Observation)s.Resource).ToList();

            return observations;
        }

        public IEnumerable<Observation> GetVitalSignByCode(string code)
        {
            var searchParameters = new SearchParams();
            searchParameters.Add("_code", code);
            var result = _client.Search(searchParameters, ResourceType.Observation.ToString());
            var observations = result.Entry.Select(s => (Observation)s.Resource).ToList();

            return observations;
        }

        public IRestResponse GetObservationByIdUsingRestClient(string patientId)
        {
            var client = new RestClient(_testEndpoint + "/Observation?_patient=456");
            var request = new RestRequest("Observation", Method.GET);
            var result = client.Execute(request);

            return result;
        }
    }
}
