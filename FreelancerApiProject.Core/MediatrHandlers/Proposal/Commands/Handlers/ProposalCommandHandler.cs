using AutoMapper;
using FreelancerApiProject.Core.Base.Resources;
using FreelancerApiProject.Core.Base.Response;
using FreelancerApiProject.Core.MediatrHandlers.Proposal.Commands.Models;
using FreelancerApiProject.Service.IServices;
using MediatR;
using Microsoft.Extensions.Localization;

namespace FreelancerApiProject.Core.MediatrHandlers.proposal.Commands.Handlers
{
    public class ProposalCommandHandler : ResponseHandler,
        IRequestHandler<AddProposalCommand, Response<string>>
        , IRequestHandler<EditProposalCommand, Response<string>>
        , IRequestHandler<DeleteProposalCommand, Response<string>>,
        IRequestHandler<AcceptProposalCommand, Response<string>>,
        IRequestHandler<RejectProposalCommand, Response<string>>
    {
        private readonly IProposalService _proposalService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public ProposalCommandHandler(IProposalService proposalService,
            IMapper mapper,
            IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _proposalService = proposalService;
            _mapper = mapper;
            _localizer = localizer;
        }


        public async Task<Response<string>> Handle(AddProposalCommand request, CancellationToken cancellationToken)
        {
            var proposalMapper = _mapper.Map<Data.Entities.Proposal>(request);

            var result = await _proposalService.CreateAsync(proposalMapper);

            return result == "Success" ? Created("") : BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(EditProposalCommand request, CancellationToken cancellationToken)
        {
            var proposal = await _proposalService.GetByIdAsync(request.Id);
            if (proposal == null) return NotFound<string>("Proposal not found in database");


            // Update the proposal's properties
            proposal.Duration = request.Duration ?? proposal.Duration;
            proposal.Description = request.Description ?? proposal.Description;
            proposal.Price = request.Price ?? proposal.Price;
            proposal.ReposLinks = request.ReposLinks ?? proposal.ReposLinks;
            proposal.Images = request.Images ?? proposal.Images;
            proposal.FreelancerId = request.FreelancerId ?? proposal.FreelancerId;
            proposal.JobId = request.JobId ?? proposal.JobId;


            var result = await _proposalService.UpdateAsync(proposal);
            return result == "Success"
                ? Success((string)_localizer[SharedResourcesKeys.Updated])
                : BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteProposalCommand request, CancellationToken cancellationToken)
        {
            var proposal = await _proposalService.GetByIdAsync(request.Id);
            if (proposal == null) return NotFound<string>();

            var result = await _proposalService.DeleteAsync(proposal);
            return result == "Success" ? Deleted<string>() : BadRequest<string>();
        }

        public async Task<Response<string>> Handle(AcceptProposalCommand request, CancellationToken cancellationToken)
        {
            // Retrieve the proposal
            var proposal = await _proposalService.GetByIdAsync(request.ProposalId);
            if (proposal == null)
                return NotFound<string>("Proposal not found in database");

            // Save changes to the proposal
            var result = await _proposalService.AcceptProposalAsync(proposal);
            return result == "Success"
                ? Success<string>("Proposal accepted successfully")
                : BadRequest<string>("Failed to accept proposal");
        }

        public async Task<Response<string>> Handle(RejectProposalCommand request, CancellationToken cancellationToken)
        {
            // Retrieve the proposal
            var proposal = await _proposalService.GetByIdAsync(request.ProposalId);
            if (proposal == null)
                return NotFound<string>("Proposal not found in database");

            // Save changes to the proposal
            var result = await _proposalService.RejectProposalAsync(proposal);
            return result == "Success"
                ? Success<string>("Proposal rejected successfully")
                : BadRequest<string>("Failed to reject proposal");
        }
    }
}