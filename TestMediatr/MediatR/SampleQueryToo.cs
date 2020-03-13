using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMediatr.MediatR
{
    public class SampleQueryToo : IRequest<SampleViewModelToo>
    {
        public string Name { get; set; }
    }
}
