namespace ElPalacio.Domain.Utils
{
    public class AppSettings
    {
        /// <summary>
        /// Gets or sets the UsersApi
        /// </summary>
        public string UsersApi { get; set; }
        /// <summary>
		/// Gets or sets the AuthApi
		/// </summary>
        public string AuthApi { get; set; }
        /// <summary>
        /// Gets or sets the segments API.
        /// </summary>
        public string SegmentsApi { get; set; }
        /// <summary>
        /// Gets or sets the BLOB storage.
        /// </summary>
        public string BlobStorage { get; set; }
        /// <summary>
        /// Gets or sets the image container.
        /// </summary>
        public string ImageContainer { get; set; }
        /// <summary>
        /// Gets or sets the icon container.
        /// </summary>
        public string IconContainer { get; set; }
        public string Secret { get; set; }
        public string SendGridApiKey { get; set; }
        public string NotificationApi { get; set; }
    }
}
