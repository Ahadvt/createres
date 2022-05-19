public IActionResult CreateRestuorant()
{
    ViewBag.Categories = _context.Categories.ToList();
    return View();
}

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> CreateRestuorant(RestuorantRegisterVM restuorantInfo)
{
    ViewBag.Categories = _context.Categories.ToList();
    if (!ModelState.IsValid) return View();
    if (restuorantInfo.ImageFile == null)
    {
        ModelState.AddModelError("ImageFile", "The field image is required");
        return View();
    }
    if (restuorantInfo.CategoryIds == null)
    {
        ModelState.AddModelError("CategoryIds", "can not be null");
        return View();
    }
    if (!restuorantInfo.ImageFile.IsImage())
    {
        ModelState.AddModelError("ImageFile", "image file must be");
        return View();
    }
    if (!restuorantInfo.ImageFile.IsSizeOk(2))
    {
        ModelState.AddModelError("ImageFile", "The field image max size 2mb");
        return View();
    }
    AppUser appUser = new AppUser
    {
        FullName = restuorantInfo.FullName,
        UserName = restuorantInfo.UserName,
        PhoneNumber = restuorantInfo.PhoneNumber,
        Email = restuorantInfo.Email,
        Role = "Restaurant"
    };
    var Result = await _userManager.CreateAsync(appUser, restuorantInfo.Password);
    if (!Result.Succeeded)
    {
        foreach (IdentityError error in Result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }
        return View();
    }
    Restuorant restuorant = new Restuorant();
    restuorant.Restuorant_Categories = new List<Restuorant_Category>();
    restuorant.Name = restuorantInfo.RestuorantName;
    restuorant.Adress = restuorantInfo.Adress;
    restuorant.Title = restuorantInfo.Title;
    restuorant.Description = restuorantInfo.Description;
    restuorant.WorkTime = restuorantInfo.WorkTime;
    restuorant.PhoneNumber = restuorantInfo.PhoneNumberRestuorant;
    restuorant.Image = restuorantInfo.ImageFile.SaveImage(_env.WebRootPath, "assets/image");
    AppUser User = await _userManager.FindByNameAsync(appUser.UserName);
    restuorant.AppUserId = User.Id;
    foreach (var id in restuorantInfo.CategoryIds)
    {
        Restuorant_Category restuorant_Category = new Restuorant_Category
        {
            Restuorant = restuorant,
            CategoryId = id
        };
        restuorant.Restuorant_Categories.Add(restuorant_Category);
    }
    _context.Restuorants.Add(restuorant);
    _context.SaveChanges();
    Restuorant CreatedRestuorant = _context.Restuorants.FirstOrDefault(cr => cr.AppUserId == User.Id);
    User.RestuorantId = CreatedRestuorant.Id;
    await _userManager.AddToRoleAsync(User, "Restaurant");
    await _userManager.UpdateAsync(User);
    await _signInManager.SignInAsync(User, true);
    return RedirectToAction("RestaurantAcceptChat", "chat");
}