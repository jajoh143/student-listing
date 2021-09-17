using Moq;
using NUnit.Framework;
using student_listing.Business.StudentBusiness;
using student_listing.Data.DAL.RegistrationDataAccess;
using student_listing.Data.DAL.StudentDataAccess;
using student_listing.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using System;

namespace student_listing.Test.BusinessTests
{
    [TestFixture]
    public class StudentBusinessTests
    {
        /// <summary>
        /// IStudentBusiness - Business layer being tested
        /// </summary>
        private IStudentBusiness _studentBusiness;

        /// <summary>
        /// Mock data access layer for student data access
        /// </summary>
        private Mock<IStudentDataAccess> _mockStudentDataAccess;

        /// <summary>
        /// Mock data access layer for the registration data access
        /// </summary>
        private Mock<IRegistrationDataAccess> _mockRegistrationDataAccess;

        [SetUp]
        public void SetUp()
        {
            _mockStudentDataAccess = new Mock<IStudentDataAccess>();
            _mockRegistrationDataAccess = new Mock<IRegistrationDataAccess>();
            _studentBusiness = new StudentBusiness(_mockStudentDataAccess.Object, _mockRegistrationDataAccess.Object);
        }

        [TestClass]
        public class GetStudentListTests : StudentBusinessTests
        {
            [TestMethod]
            public async Task Success()
            {
                List<Student> studentList = new List<Student>
                {
                    new Student() { FirstName = "testFirstName", LastName = "testLastName", Email = "testEmail" },
                    new Student() { FirstName = "testFirstName2", LastName = "testLastName2", Email  = "testEmail2" }
                };

                _mockStudentDataAccess.Setup(mock => mock.GetStudents()).Returns(Task.FromResult<IEnumerable<Student>>(studentList));
                IEnumerable<Student> students = await _studentBusiness.GetStudentList();
                Assert.AreEqual(2, students.Count());
                Assert.AreEqual("testFirstName", students.ElementAt(0).FirstName);
                Assert.AreEqual("testLastName", students.ElementAt(0).LastName);
                Assert.AreEqual("testEmail", students.ElementAt(0).Email);
                Assert.AreEqual("testFirstName2", students.ElementAt(1).FirstName);
                Assert.AreEqual("testLastName2", students.ElementAt(1).LastName);
                Assert.AreEqual("testEmail2", students.ElementAt(1).Email);
            }
        }

        [TestClass]
        public class GetStudentTests : StudentBusinessTests
        {
            [TestMethod]
            public async Task Success()
            {
                Student studentReturnObject = new Student
                {
                    FirstName = "testFirstName",
                    LastName = "testLastName",
                    Email = "testEmail",
                    CourseList = "test, test",
                    CumulativeGpa = 4,
                    StudentId = 1
                };

                List<Registration> registrations = new List<Registration>
                {
                        new Registration { RegistrationId = 1, CourseId = 2, StudentId = 1, CourseHours = 4 },
                        new Registration { RegistrationId = 2, CourseId = 3, StudentId = 1, GradeScore = 4 }
                };


                _mockStudentDataAccess.Setup(mock => mock.GetStudent(1)).Returns(Task.FromResult(studentReturnObject));
                _mockRegistrationDataAccess.Setup(mock => mock.GetRegistrationListForStudent(1)).Returns(Task.FromResult<IEnumerable<Registration>>(registrations));

                Student student = await _studentBusiness.GetStudent(1);

                Assert.AreEqual(1, student.StudentId);
                Assert.AreEqual("testFirstName", student.FirstName);
                Assert.AreEqual("testLastName", student.LastName);
                Assert.AreEqual("testEmail", student.Email);
                Assert.AreEqual("test, test", student.CourseList);
                Assert.AreEqual(4, student.CumulativeGpa);
                Assert.AreEqual(2, student.Registrations.Count());
                Assert.AreEqual(1, student.Registrations.ElementAt(0).RegistrationId);
                Assert.AreEqual(2, student.Registrations.ElementAt(0).CourseId);
                Assert.AreEqual(1, student.Registrations.ElementAt(0).StudentId);
                Assert.AreEqual(4, student.Registrations.ElementAt(0).CourseHours);
                Assert.AreEqual(2, student.Registrations.ElementAt(1).RegistrationId);
                Assert.AreEqual(3, student.Registrations.ElementAt(1).CourseId);
                Assert.AreEqual(1, student.Registrations.ElementAt(1).StudentId);
                Assert.AreEqual(4, student.Registrations.ElementAt(1).GradeScore);
            }

            [TestMethod]
            public void Should_Throw_Argument_Error()
            {
                ArgumentOutOfRangeException ex = Assert.ThrowsAsync<ArgumentOutOfRangeException>(async() => await _studentBusiness.GetStudent(0));
                Assert.That(ex.Message, Is.EqualTo("Invalid student id provided (Parameter 'studentId')"));
            }
        }
    }
}
