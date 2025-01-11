using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Resourses
{
    public class SharedResoursesKeys
    {
        public const string Required = "required";
        public const string NotFound = "NotFound";
        public const string Deleted = "Deleted";
        public const string Created = "Created";
        public const string Update = "Update";
        public const string Success = "Success";
        public const string NotEmpty = "NotEmpty";
        public const string Empty = "Empty";
        public const string Name = "Name";
        public const string MaxLengthis100 = "MaxLengthis100";
        public const string IsExist = "IsExist";
        public const string DepartmentNotExsists = "DepartmentNotExsists";
        public const string PasswordNotEqualConfirmPass = "PasswordNotEqualConfirmPass";
        public const string EmailAlreadyExsists = "EmailAlreadyExsists";
        public const string UserNameIsAlreadyExsists = "UserNameIsAlreadyExsists";
        public const string FaliedToAddUser = "FaliedToAddUser";
        public const string UpdateFailed = "UpdateFailed";
        public const string FailedToDeleteUser = "FailedToDeleteUser";
        public const string UserName = "UserName";
        public const string Password = "Password";
        public const string UserNameIsNotExist = "UserNameIsNotExist";
        public const string PasswordNotCorrect = "PasswordNotCorrect";
        public const string EmailNotConfirmed = "EmailNotConfirmed";
        public const string UnAuthorized = "UnAuthorized";
        public const string AlgorithmIsWrong = "AlgorithmIsWrong";
        public const string TokenIsNotExpired = "TokenIsNotExpired";
        public const string RefreshTokenIsNotFound = "RefreshTokenIsNotFound";
        public const string RefreshTokenIsExpired = "RefreshTokenIsExpired";
        public const string FaliedToAddRole = "FaliedToAddRole";
        public const string RoleIsUsed = "RoleIsUsed";
        public const string UserIsNotFound = "UserIsNotFound";
        public const string FailedToRemoveOldRoles = "FailedToRemoveOldRoles";
        public const string FailedToAddNewRoles = "FailedToAddNewRoles";
        public const string FailedToUpdateUserRoles = "FailedToUpdateUserRoles";
        public const string FailedToRemoveOldClaims = "FailedToRemoveOldClaims";
        public const string FailedToAddNewClaims = "FailedToAddNewClaims";
        public const string FailedToUpdateClaims = "FailedToUpdateClaims";
        public const string SendEmailFailed = "SendEmailFailed";
        public const string ErrorWhenConfirmEmail = "ErrorWhenConfirmEmail";
        public const string ConfirmEmailDone = "ConfirmEmailDone";
        public const string EmailIsExist = "EmailIsExist";
        public const string UserNameIsExist = "UserNameIsExist";
        public const string FaildToAddUser = "FaildToAddUser";
        public const string TryToRegisterAgain = "TryToRegisterAgain";
        public const string TryAgainInAnotherTime = "TryAgainInAnotherTime";
        public const string InvaildCode = "InvaildCode";
        public const string AlreadyExsists = "AlreadyExsists";
        public const string AlreadyNotExsists = "AlreadyNotExsists";
        public const string ProductIsNotFound = "ProductIsNotFound";
        public const string CartIsEmpty = "CartIsEmpty";

        // User and Authentication
        public const string EmailAlreadyExists = "EmailAlreadyExists";
        public const string UserNameIsAlreadyExists = "UserNameIsAlreadyExists";


        // Role and Claims
        public const string FailedToAddRole = "FailedToAddRole";
   

        // Email and Tokens
        public const string InvalidCode = "InvalidCode";

        // Cart Operations
        public const string CartNotFound = "CartNotFound";
        public const string ProductNotFoundInCart = "ProductNotFoundInCart";
        public const string ProductAddedToCart = "ProductAddedToCart";
        public const string ProductRemovedFromCart = "ProductRemovedFromCart";
        public const string CartCleared = "CartCleared";
        public const string CartItemQuantityIncreased = "CartItemQuantityIncreased";
        public const string CartItemQuantityDecreased = "CartItemQuantityDecreased";

        // Orders
        public const string OrderNotFound = "OrderNotFound";
        public const string OrderPlaced = "OrderPlaced";
        public const string OrderCancelled = "OrderCancelled";
        public const string OrderUpdated = "OrderUpdated";
        public const string OrderPaymentFailed = "OrderPaymentFailed";

        // Payments
        public const string PaymentFailed = "PaymentFailed";
        public const string PaymentSuccessful = "PaymentSuccessful";

        // Product and Inventory
        public const string ProductNotFound = "ProductNotFound";
        public const string ProductAlreadyExists = "ProductAlreadyExists";
        public const string InsufficientStock = "InsufficientStock";
        public const string ProductAdded = "ProductAdded";
        public const string ProductUpdated = "ProductUpdated";
        public const string ProductDeleted = "ProductDeleted";

        // Wishlist/Favorites
        public const string FavoriteListNotFound = "FavoriteListNotFound";
        public const string ProductAddedToFavorites = "ProductAddedToFavorites";
        public const string ProductRemovedFromFavorites = "ProductRemovedFromFavorites";
        public const string FavouriteListCleared = "FavouriteListCleared";

        // Reviews
        public const string ReviewNotFound = "ReviewNotFound";
        public const string ReviewAdded = "ReviewAdded";
        public const string ReviewUpdated = "ReviewUpdated";
        public const string ReviewDeleted = "ReviewDeleted";
        public const string ReviewAlreadyExists = "ReviewAlreadyExists";

        // Reviews 
        public const string FaliedToAddBlog = "Faild To Add Blog";


        // General Errors
        public const string AlreadyExists = "AlreadyExists";
        public const string DoesNotExist = "DoesNotExist";
        public const string OperationFailed = "OperationFailed";
        public const string OperationSuccessful = "OperationSuccessful";
        public const string InvalidInput = "InvalidInput";
        public const string UnauthorizedAccess = "UnauthorizedAccess";
        public const string AccessDenied = "AccessDenied";
        public const string ValidationFailed = "ValidationFailed";
    }
}
