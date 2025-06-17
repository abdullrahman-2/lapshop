namespace lapshop.Helpers
{
    public static class  clsHelper
    {
        public static string UpldadFile(IFormFile files)
        {

            if (files.Length > 0)
            {

                string imageName = Guid.NewGuid().ToString() + ".jpg";

                var FilePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", imageName);

                using (var stream = System.IO.File.Create(FilePath))

                {
                    files.CopyTo(stream);
                    return imageName;
                }

            }
            else
                return "";
        }
    }
}
