﻿namespace Cavity.Net
{
    using System;

    using Xunit;

    public sealed class HttpVersionFacts
    {
        [Fact]
        public void a_definition()
        {
            Assert.True(new TypeExpectations<HttpVersion>()
                            .DerivesFrom<ComparableObject>()
                            .IsConcreteClass()
                            .IsSealed()
                            .NoDefaultConstructor()
                            .IsNotDecorated()
                            .Result);
        }

        [Fact]
        public void ctor_int_int()
        {
            Assert.NotNull(new HttpVersion(1, 0));
        }

        [Fact]
        public void opImplicit_HttpVersion_string()
        {
            var expected = new HttpVersion(1, 0);
            HttpVersion actual = "HTTP/1.0";

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void opImplicit_HttpVersion_stringEmpty()
        {
            Assert.Throws<FormatException>(() => (HttpVersion)string.Empty);
        }

        [Fact]
        public void opImplicit_HttpVersion_stringNull()
        {
            Assert.Null((HttpVersion)null);
        }

        [Fact]
        public void op_FromString_string()
        {
            var expected = new HttpVersion(1, 0);
            var actual = HttpVersion.FromString("HTTP/1.0");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void op_FromString_stringEmpty()
        {
            Assert.Throws<FormatException>(() => HttpVersion.FromString(string.Empty));
        }

        [Fact]
        public void op_FromString_stringNull()
        {
            Assert.Throws<ArgumentNullException>(() => HttpVersion.FromString(null));
        }

        [Fact]
        public void op_FromString_string_Invalid()
        {
            Assert.Throws<FormatException>(() => HttpVersion.FromString("1.0"));
        }

        [Fact]
        public void op_ToString()
        {
            const string expected = "HTTP/1.0";
            var actual = new HttpVersion(1, 0).ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void prop_Major()
        {
            Assert.True(new PropertyExpectations<HttpVersion>(p => p.Major)
                            .TypeIs<int>()
                            .ArgumentOutOfRangeException(-1)
                            .Set(0)
                            .Set(1)
                            .Set(2)
                            .Set(3)
                            .Set(4)
                            .Set(5)
                            .Set(6)
                            .Set(7)
                            .Set(8)
                            .Set(9)
                            .ArgumentOutOfRangeException(10)
                            .IsNotDecorated()
                            .Result);
        }

        [Fact]
        public void prop_Minor()
        {
            Assert.True(new PropertyExpectations<HttpVersion>(p => p.Minor)
                            .TypeIs<int>()
                            .ArgumentOutOfRangeException(-1)
                            .Set(0)
                            .Set(1)
                            .Set(2)
                            .Set(3)
                            .Set(4)
                            .Set(5)
                            .Set(6)
                            .Set(7)
                            .Set(8)
                            .Set(9)
                            .ArgumentOutOfRangeException(10)
                            .IsNotDecorated()
                            .Result);
        }
    }
}