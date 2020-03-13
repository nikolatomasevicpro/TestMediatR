using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestMediatr.MediatR
{
    public class SampleHandlerToo : IRequestHandler<SampleQueryToo, SampleViewModelToo>
    {
        public SampleHandlerToo()
        {
        }

        public async Task<SampleViewModelToo> Handle(SampleQueryToo request, CancellationToken cancellationToken)
        {
            return new SampleViewModelToo
            {
                Id = Guid.NewGuid()
            };
        }
    }
}
