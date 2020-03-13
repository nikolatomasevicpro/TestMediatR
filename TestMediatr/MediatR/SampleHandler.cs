using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestMediatr.MediatR
{
    public class SampleHandler : IRequestHandler<SampleQuery, SampleViewModel>
    {
        public SampleHandler()
        {
        }

        public async Task<SampleViewModel> Handle(SampleQuery request, CancellationToken cancellationToken)
        {
            return new SampleViewModel
            {
                Name = "It woks!"
            };
        }
    }
}
