using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using IMSApi.Controllers;
using IMSApi.Interfaces;
using IMSApi.Models;
using IMSApi.Dtos.Appointment;
using IMSApi.Data;
using Microsoft.EntityFrameworkCore;

namespace IMSApi.Tests
{
    public class AppointmentControllerTests
    {
        private readonly Mock<IAppointmentRepository> _mockAppointmentRepo;
        private readonly Mock<IPatientRepository> _mockPatientRepo;
        private readonly AppointmentController _controller;
        private readonly AppDBContext _context;

        public AppointmentControllerTests()
        {
            // Setup mock repositories
            _mockAppointmentRepo = new Mock<IAppointmentRepository>();
            _mockPatientRepo = new Mock<IPatientRepository>();

            // Setup in-memory database
            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;
            _context = new AppDBContext(options);

            // Initialize controller with mocked dependencies
            _controller = new AppointmentController(_context, _mockAppointmentRepo.Object, _mockPatientRepo.Object);
        }

        [Fact]
        public async Task Create_ValidAppointment_ReturnsOkResult()
        {
            // Arrange
            var patientId = 1;
            var appointmentDto = new AppointmentDto
            {
                DoctorId = 1,
                Date = DateTime.UtcNow,
                Description = "Test appointment",
                Status = "Scheduled",
                CreatedAt = DateTime.UtcNow
            };

            _mockPatientRepo.Setup(repo => repo.PatientExists(patientId))
                .ReturnsAsync(true);

            var appointment = new Appointment
            {
                Id = 1,
                PatientId = patientId,
                DoctorId = appointmentDto.DoctorId,
                Date = appointmentDto.Date,
                Description = appointmentDto.Description,
                Status = appointmentDto.Status,
                CreatedAt = appointmentDto.CreatedAt
            };

            _mockAppointmentRepo.Setup(repo => repo.CreateAsync(It.IsAny<Appointment>()))
                .ReturnsAsync(appointment);

            // Act
            var result = await _controller.Create(patientId, appointmentDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Appointment>(okResult.Value);
            Assert.Equal(patientId, returnValue.PatientId);
            Assert.Equal(appointmentDto.DoctorId, returnValue.DoctorId);
        }

        [Fact]
        public async Task Create_InvalidPatientId_ReturnsBadRequest()
        {
            // Arrange
            var patientId = 999; // Non-existent patient ID
            var appointmentDto = new AppointmentDto
            {
                DoctorId = 1,
                Date = DateTime.UtcNow,
                Description = "Test appointment",
                Status = "Scheduled",
                CreatedAt = DateTime.UtcNow
            };

            _mockPatientRepo.Setup(repo => repo.PatientExists(patientId))
                .ReturnsAsync(false);

            // Act
            var result = await _controller.Create(patientId, appointmentDto);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task GetById_ExistingAppointment_ReturnsOkResult()
        {
            // Arrange
            var appointmentId = 1;
            var appointmentDto = new AppointmentDto
            {
                Id = appointmentId,
                PatientId = 1,
                DoctorId = 1,
                Date = DateTime.UtcNow,
                Description = "Test appointment",
                Status = "Scheduled",
                CreatedAt = DateTime.UtcNow
            };

            _mockAppointmentRepo.Setup(repo => repo.GetByIdAsync(appointmentId))
                .ReturnsAsync(appointmentDto);

            // Act
            var result = await _controller.GetById(appointmentId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<AppointmentDto>(okResult.Value);
            Assert.Equal(appointmentId, returnValue.Id);
        }

        [Fact]
        public async Task GetById_NonExistingAppointment_ReturnsNotFound()
        {
            // Arrange
            var appointmentId = 999; // Non-existent appointment ID

            _mockAppointmentRepo.Setup(repo => repo.GetByIdAsync(appointmentId))
                .ReturnsAsync((AppointmentDto)null);

            // Act
            var result = await _controller.GetById(appointmentId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetAllByDoctorId_ExistingAppointments_ReturnsOkResult()
        {
            // Arrange
            var doctorId = 1;
            var appointments = new List<AppointmentDto>
            {
                new AppointmentDto
                {
                    Id = 1,
                    PatientId = 1,
                    DoctorId = doctorId,
                    Date = DateTime.UtcNow,
                    Description = "Test appointment 1",
                    Status = "Scheduled",
                    CreatedAt = DateTime.UtcNow
                },
                new AppointmentDto
                {
                    Id = 2,
                    PatientId = 2,
                    DoctorId = doctorId,
                    Date = DateTime.UtcNow,
                    Description = "Test appointment 2",
                    Status = "Scheduled",
                    CreatedAt = DateTime.UtcNow
                }
            };

            _mockAppointmentRepo.Setup(repo => repo.GetAllByDoctorIdAsync(doctorId))
                .ReturnsAsync(appointments);

            // Act
            var result = await _controller.GetAllByDoctorId(doctorId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<AppointmentDto>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task GetAllByPatientId_ExistingAppointments_ReturnsOkResult()
        {
            // Arrange
            var patientId = 1;
            var appointments = new List<AppointmentDto>
            {
                new AppointmentDto
                {
                    Id = 1,
                    PatientId = patientId,
                    DoctorId = 1,
                    Date = DateTime.UtcNow,
                    Description = "Test appointment 1",
                    Status = "Scheduled",
                    CreatedAt = DateTime.UtcNow
                },
                new AppointmentDto
                {
                    Id = 2,
                    PatientId = patientId,
                    DoctorId = 2,
                    Date = DateTime.UtcNow,
                    Description = "Test appointment 2",
                    Status = "Scheduled",
                    CreatedAt = DateTime.UtcNow
                }
            };

            _mockAppointmentRepo.Setup(repo => repo.GetAllByPatientIdAsync(patientId))
                .ReturnsAsync(appointments);

            // Act
            var result = await _controller.GetAllByPatientId(patientId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<AppointmentDto>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }
    }
} 