using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit;

namespace RulesEngineSamplesTests
{
    public class NSubDataAttribute : AutoDataAttribute
    {
        public NSubDataAttribute()
            : base(new Fixture())
        {
        }
    }
}
