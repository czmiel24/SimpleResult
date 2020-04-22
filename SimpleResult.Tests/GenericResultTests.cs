using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace SimpleResult.Tests
{
    public class GenericResultTests
    {
        [TestCase(true)]
        [TestCase(false)]
        public void Value_StringPassedToConstructor_ReturnsString(bool isSuccess)
        {
            Result<string> result = new Result<string>(isSuccess, "string");

            Assert.That(result.Value, Is.EqualTo("string"));
            Assert.That(result.IsSuccess, Is.EqualTo(isSuccess));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Value_ObjectPassedToConstructor_ReturnsObject(bool isSuccess)
        {
            Object testObject = new Object();
            Result<Object> result = new Result<Object>(isSuccess, testObject);

            Assert.That(result.Value, Is.EqualTo(testObject));
            Assert.That(result.IsSuccess, Is.EqualTo(isSuccess));
        }

        [Test]
        public void Value_ErrorAndObjectPassedToConstructor_ReturnsFailedResultWithErrorAndValue()
        {
            Object testObject = new Object();
            Result<Object> result = new Result<Object>(new Error("1"), testObject);

            Assert.That(result.Errors[0].Message, Is.EqualTo("1"));
            Assert.That(result.Value, Is.EqualTo(testObject));
            Assert.That(result.IsSuccess, Is.False);
        }

        [Test]
        public void Value_ErrorListAndObjectPassedToConstructor_ReturnsFailedResultObjectWithErrorsAndValue()
        {
            Object testObject = new Object();
            Result<Object> result = new Result<Object>(new List<Error>{new Error("1")}, testObject);

            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.Errors[0].Message, Is.EqualTo("1"));
            Assert.That(result.Value, Is.EqualTo(testObject));
        }

        [Test]
        public void Success_ObjectPassed_ReturnsSuccessResultWithValue()
        {
            Object testObject = new Object();
            Result<Object> result = Result<Object>.Success(testObject);

            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Value, Is.EqualTo(testObject));
        }

        [Test]
        public void Failure_ObjectPassed_ReturnsFailedResultWithValue()
        {
            Object testObject = new Object();
            Result<Object> result = Result<Object>.Failure(testObject);

            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.Value, Is.EqualTo(testObject));
        }

        [Test]
        public void Failure_ErrorAndObjectPassed_ReturnsFailedResultWithErrorAndValue()
        {
            Object testObject = new Object();
            Result<Object> result = Result<Object>.Failure(new Error("1"), testObject);

            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.Errors[0].Message, Is.EqualTo("1"));
            Assert.That(result.Value, Is.EqualTo(testObject));
        }

        [Test]
        public void Failure_ErrorListAndObjectPassed_ReturnsFailedResultObjectWithErrorsAndValue()
        {
            Object testObject = new Object();
            Result<Object> result = Result<Object>.Failure(new List<Error>{new Error("1")}, testObject);

            Assert.That(result.IsSuccess, Is.False);
            Assert.That(result.Errors[0].Message, Is.EqualTo("1"));
            Assert.That(result.Value, Is.EqualTo(testObject));
        }
    }
}