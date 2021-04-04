using Koralium.Shared;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Koralium.Core.Tests
{
    public class CircularDependencyTests
    {
        private class SingleCircularType
        {
            public SingleCircularType P1 { get; set; }
        }

        private class SingleCircularTypeResolver : TableResolver<SingleCircularType>
        {
            protected override Task<IQueryable<SingleCircularType>> GetQueryableData(IQueryOptions<SingleCircularType> queryOptions, ICustomMetadata customMetadata)
            {
                throw new System.NotImplementedException();
            }
        }

        private class TwoCircularType
        {
            public TwoCircularTypeOther P1 { get; set; }
        }

        private class TwoCircularTypeOther
        {
            public TwoCircularType P2 { get; set; }
        }

        private class TwoCircularTypeResolver : TableResolver<TwoCircularType>
        {
            protected override Task<IQueryable<TwoCircularType>> GetQueryableData(IQueryOptions<TwoCircularType> queryOptions, ICustomMetadata customMetadata)
            {
                throw new NotImplementedException();
            }
        }

        private class NoCircularType
        {
            public string P1 { get; set; }

            public NoCircularTypeInner P2 { get; set; }

            public NoCircularTypeInner P3 { get; set; }

            [KoraliumIgnore]
            public NoCircularType P4 { get; set; }
        }

        private class NoCircularTypeInner
        {
            public string P1 { get; set; }
        }

        private class NoCircularTypeResolver : TableResolver<NoCircularType>
        {
            protected override Task<IQueryable<NoCircularType>> GetQueryableData(IQueryOptions<NoCircularType> queryOptions, ICustomMetadata customMetadata)
            {
                throw new NotImplementedException();
            }
        }

        [Test]
        public void TestCircularDependencyLength1()
        {
            ServiceCollection services = new ServiceCollection();

            Assert.That(() =>
            {
                services.AddKoralium(opt =>
                {
                    opt.AddTableResolver<SingleCircularTypeResolver, SingleCircularType>();
                });
            }, Throws.Exception.TypeOf<InvalidOperationException>().And.Message.EqualTo("Circular dependency found in type: 'SingleCircularType', path: 'P1 (SingleCircularType)'"));
        }

        [Test]
        public void TestCircularDependencyLength2()
        {
            ServiceCollection services = new ServiceCollection();

            Assert.That(() =>
            {
                services.AddKoralium(opt =>
                {
                    opt.AddTableResolver<TwoCircularTypeResolver, TwoCircularType>();
                });
            }, Throws.Exception.TypeOf<InvalidOperationException>().And.Message.EqualTo("Circular dependency found in type: 'TwoCircularType', path: 'P1 (TwoCircularTypeOther) -> P2 (TwoCircularType)'"));
        }

        [Test]
        public void TestNoCircularDependency()
        {
            ServiceCollection services = new ServiceCollection();

            Assert.That(() =>
            {
                services.AddKoralium(opt =>
                {
                    opt.AddTableResolver<NoCircularTypeResolver, NoCircularType>();
                });
            }, Throws.Nothing);
        }
    }
}