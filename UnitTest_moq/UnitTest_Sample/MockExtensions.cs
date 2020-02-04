using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Barton.UnitTest
{
    public static class MockExtensions
    {
        public static void AddList<T>(this Mock mock, params T[] entities)
        {
            var list = entities.ToList<T>().AsQueryable();
            mock.As<IQueryable<T>>().Setup(x => x.Provider).Returns(list.Provider);
            mock.As<IQueryable<T>>().Setup(x => x.Expression).Returns(list.Expression);
            mock.As<IQueryable<T>>().Setup(x => x.ElementType).Returns(list.ElementType);
            mock.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(list.GetEnumerator());
        }
        public static void AsQuerable<T>(this Mock mock)
        {
            var list = new List<T>().AsQueryable(); 
            mock.As<IQueryable<T>>().Setup(x => x.Provider).Returns(list.Provider);
            mock.As<IQueryable<T>>().Setup(x => x.Expression).Returns(list.Expression);
            mock.As<IQueryable<T>>().Setup(x => x.ElementType).Returns(list.ElementType);
            mock.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(list.GetEnumerator());
        }
    }
}
