using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TestMediatr.MediatR
{
    public class SampleQuery : IRequest<SampleViewModel>
    {
        public Guid Id { get; set; }
    }
}
