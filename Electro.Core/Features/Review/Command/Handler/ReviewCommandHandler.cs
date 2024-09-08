using AutoMapper;
using Electro.Core.Features.Review.Command.Models;
using Electro.Core.Resourses;
using Electro.Core.ResponseHelper;
using Electro.Data.Entites;
using Electro.Services.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;


namespace Electro.Core.Features.Review.Command.Handler
{
    public class ReviewCommandHandler : ResponseHandler,
        IRequestHandler<AddReviewModel,Response<string>>,
        IRequestHandler<UpdateReviewModel,Response<string>>,
        IRequestHandler<DeleteReviewModel,Response<string>>

    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResourses> _localizer;
        private readonly IReviewServices _reviewServices;
        #endregion

        #region Constructor
        public ReviewCommandHandler(IMapper mapper, IStringLocalizer<SharedResourses> localizer , IReviewServices reviewServices) : base(localizer)
        {
            _mapper = mapper;
            _localizer = localizer;
            _reviewServices = reviewServices;
        }
        #endregion

        #region Actions 
        public async Task<Response<string>> Handle(AddReviewModel request, CancellationToken cancellationToken)
        {
            var review = _mapper.Map<Data.Entites.Review>(request);
            
            await _reviewServices.AddReview(review);

            return Success<string>(_localizer[SharedResoursesKeys.ReviewAdded]);
        }

        public async Task<Response<string>> Handle(UpdateReviewModel request, CancellationToken cancellationToken)
        {
            var review = _mapper.Map<Data.Entites.Review>(request);

            await _reviewServices.UpdateReview(review);

            return Success<string>(_localizer[SharedResoursesKeys.ReviewUpdated]);
        }

        public async Task<Response<string>> Handle(DeleteReviewModel request, CancellationToken cancellationToken)
        {
            var result = await _reviewServices.DeleteReview(request.Id);
            
            if(result != "Success")
            {
                return BadRequest<string>(_localizer[SharedResoursesKeys.ReviewNotFound]);
            }
            return Success<string>(_localizer[SharedResoursesKeys.ReviewDeleted]);
        }

        #endregion
    }
}
