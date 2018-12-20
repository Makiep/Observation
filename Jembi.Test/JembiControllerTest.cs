using Microsoft.Extensions.Configuration;
using Moq;
using Jembi.Core.Interfaces;
using Xunit;
using Jembi.Controllers;
using Hl7.Fhir.Model;
using Microsoft.AspNetCore.Mvc;

namespace Jembi.Test
{
    /*
     Example Unit Tests
    */

    public class JembiControllerTest
    {
        private ObserverController controller;

        private Mock<IObservationService> _observationService;
        private Mock<IObservationManager> _observerManager;
        private Mock<IConfiguration> _config;

        public JembiControllerTest()
        {
            _observationService = new Mock<IObservationService>();
            _observerManager = new Mock<IObservationManager>();
            _config = new Mock<IConfiguration>();

            controller = new ObserverController(_observationService.Object);
        }

        [Fact]
        public void CreateObervation_ReturnsSuccess_CorrectId()
        {
            //Arrange
            string code = "8480-6";
            decimal value = 0;

            _observationService.Setup(service => service.Create(code, value))
                .Returns(new Observation());

            //Act
            var result = controller.CreateObservation(code, value) as IActionResult;

            //    // Assert
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public void GetVitalSignByPatient_ReturnsSuccess_CorrectVitalSigns()
        {
            //Arrange
            string patientId = "456";
            Observation obz1 = new Observation();
            Observation obz2 = new Observation();

            _observationService.Setup(service => service.GetVitalSignByPatient(patientId))
                .Returns(new[] {
                obz1,
                obz2 });

            //Act
            var result = controller.GetVitalSignByPatient(patientId) as IActionResult;

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
       

        [Fact]
        public void GetVitalSignByPatientAndCode_ReturnsSuccess_CorrectVitalSigns()
        {
            //Arrange
            string patientId = "456";
            string code = "8480-6";

            Observation obz1 = new Observation();
            Observation obz2 = new Observation();

            _observationService.Setup(service => service.GetVitalSignByPatientAndCode(patientId, code))
                .Returns(new[] {
                obz1,
                obz2 });

            //Act
            var result = controller.GetVitalSignByPatientAndCode(patientId, code) as IActionResult;

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}