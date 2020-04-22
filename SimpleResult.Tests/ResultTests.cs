using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace SimpleResult.Tests
{
    public class ResultTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Errors_FailedResultWithError_ReturnErrors()
        {
            Result result = new Result(new Error());

            Assert.That(result.Errors[0], Is.TypeOf(typeof(Error)));
            Assert.That(result.IsSuccess, Is.False);
        }

        [Test]
        public void Constructor_NullErrorParam_ThrowsArgumentNullException()
        {
            Error error = null;
            Assert.Throws<ArgumentNullException>(() => new Result(error));
        }

        [Test]
        public void Errors_FailedResultWithErrors_ReturnErrors()
        {
            Result result = new Result(new List<Error>() { new Error("1") });

            Assert.That(result.Errors[0].Message, Is.EqualTo("1"));
            Assert.That(result.IsSuccess, Is.False);
        }
        
        [Test]
        public void Constructor_NullErrorsParam_ThrowsArgumentNullException()
        {
            List<Error> errors = null;
            Assert.Throws<ArgumentNullException>(() => new Result(errors));
        }

        [Test]
        public void AddError_NormalErrorPassed_ErrorShouldBeAdded()
        {
            Result result = new Result(true);
            result.AddError(new Error("1"));

            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.Errors[0].Message, Is.EqualTo("1"));
        }

        [Test]
        public void AddError_NullErrorPassed_ThrowsArgumentNullException()
        {
            Result result = new Result(false);

            Assert.Throws<ArgumentNullException>(() => result.AddError(null));
        }

        [Test]
        public void Success_SuccessResult_ReturnsSuccessfullResult()
        {
            Result result = Result.Success();

            Assert.That(result.IsSuccess, Is.True);
        }

        [Test]
        public void Failure_NoParamsPassed_ReturnsFailedResult()
        {
            Result result = Result.Failure();

            Assert.That(result.IsSuccess, Is.False);
        }

        [Test]
        public void Failure_ErrorPassed_ReturnsFailedResultWithError()
        {
            Result result = Result.Failure(new Error("1"));

            Assert.That(result.Errors[0].Message, Is.EqualTo("1"));
            Assert.That(result.IsSuccess, Is.False);
        }

        [Test]
        public void Failure_ErrorListPassed_ReturnsFailedResultObjectWithErrors()
        {
            Result result = Result.Failure(new List<Error>{new Error("1")});

            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.Errors[0].Message, Is.EqualTo("1"));
        }
    }
}