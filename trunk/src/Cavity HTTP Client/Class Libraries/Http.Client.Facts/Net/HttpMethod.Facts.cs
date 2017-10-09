﻿namespace Cavity.Net
{
    using System;

    using Xunit;

    public sealed class HttpMethodFacts
    {
        [Fact]
        public void a_definition()
        {
            Assert.True(new TypeExpectations<HttpMethod>()
                            .DerivesFrom<ComparableObject>()
                            .IsConcreteClass()
                            .IsSealed()
                            .NoDefaultConstructor()
                            .IsNotDecorated()
                            .Result);
        }

        [Fact]
        public void ctor_string()
        {
            Assert.NotNull(new HttpMethod("GET"));
        }

        [Fact]
        public void ctor_stringEmpty()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new HttpMethod(string.Empty));
        }

        [Fact]
        public void ctor_stringNull()
        {
            Assert.Throws<ArgumentNullException>(() => new HttpMethod(null));
        }

        [Fact]
        public void opImplicit_HttpMethod_string()
        {
            var expected = new HttpMethod("GET");
            HttpMethod actual = "GET";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void opImplicit_HttpMethod_stringEmpty()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => (HttpMethod)string.Empty);
        }

        [Fact]
        public void opImplicit_HttpMethod_stringNull()
        {
            Assert.Null((HttpMethod)null);
        }

        [Fact]
        public void op_ToString()
        {
            const string expected = "GET";
            var actual = new HttpMethod(expected).ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void prop_Connect()
        {
            Assert.Equal<HttpMethod>("CONNECT", HttpMethod.Connect);
        }

        [Fact]
        public void prop_Delete()
        {
            Assert.Equal<HttpMethod>("DELETE", HttpMethod.Delete);
        }

        [Fact]
        public void prop_Get()
        {
            Assert.Equal<HttpMethod>("GET", HttpMethod.Get);
        }

        [Fact]
        public void prop_Head()
        {
            Assert.Equal<HttpMethod>("HEAD", HttpMethod.Head);
        }

        [Fact]
        public void prop_Options()
        {
            Assert.Equal<HttpMethod>("OPTIONS", HttpMethod.Options);
        }

        [Fact]
        public void prop_Post()
        {
            Assert.Equal<HttpMethod>("POST", HttpMethod.Post);
        }

        [Fact]
        public void prop_Put()
        {
            Assert.Equal<HttpMethod>("PUT", HttpMethod.Put);
        }

        [Fact]
        public void prop_Trace()
        {
            Assert.Equal<HttpMethod>("TRACE", HttpMethod.Trace);
        }

        [Fact]
        public void prop_Value()
        {
            Assert.True(new PropertyExpectations<HttpMethod>(p => p.Value)
                            .TypeIs<string>()
                            .ArgumentOutOfRangeException(string.Empty)
                            .FormatException("FOO BAR")
                            .FormatException("FOO123BAR")
                            .Set("OPTIONS")
                            .Set("GET")
                            .Set("HEAD")
                            .Set("POST")
                            .Set("PUT")
                            .Set("DELETE")
                            .Set("TRACE")
                            .Set("CONNECT")
                            .IsNotDecorated()
                            .Result);
        }
    }
}