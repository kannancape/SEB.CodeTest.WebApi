using CodeTest.Domain.Contract;
using CodeTest.Domain.Contract.Response;
using MediatR;

namespace CodeTest.Domain.Commands
{
    public class CreateTestCommand : IRequest<CreateTestResponse>
    {
        public CreateTestRequest _testRequest;
        public CreateTestCommand(CreateTestRequest testResquest)
        {
            this._testRequest = testResquest;
        }
        public CreateTestCommand()
        { }
    }
}
