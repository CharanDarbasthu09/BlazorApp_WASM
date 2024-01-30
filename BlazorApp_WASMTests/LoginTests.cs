
using BlazorApp_WASM.Pages;
using BlazorApp_WASM.Utilities;

using Bunit;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;

using Moq;

namespace BlazorApp_WASMTests
{
  public class LoginTests
  {
    private readonly Mock<ILocalStorage> _localStorage = new();

    private readonly TestContext _testContext;
    public LoginTests()
    {
      _localStorage = new Mock<ILocalStorage>();
      _testContext = new TestContext();

      _testContext.Services.AddSingleton(_localStorage.Object);
    }

    [Fact]
    public void Login_MarkUp_Test()
    {
      var expectedMarkUp = "<h1>User Login</h1>\r\n<div class=\"modal-content\">\r\n  <div class=\"modal-header\">\r\n    <h5 class=\"modal-title\">Login Form</h5>\r\n  </div>\r\n  <div class=\"modal-body\">\r\n    <div class=\"mb-3\">\r\n      <label for=\"loginEmail\" class=\"form-label\">Email</label>\r\n      <input type=\"email\" class=\"form-control\" id=\"loginEmail\" placeholder=\"name@example.com\" autocomplete=\"off\" required=\"\" >\r\n    </div>\r\n    <div class=\"mb-3\">\r\n      <label for=\"loginPassword\" class=\"form-label\">Password</label>\r\n      <input type=\"password\" class=\"form-control\" id=\"loginPassword\" required=\"\" >\r\n    </div>\r\n  </div>\r\n  <div class=\"modal-footer\">\r\n    <button id=\"loginBtn\" type=\"button\" class=\"btn btn-success\" >Login</button>\r\n  </div>\r\n  <div class=\"toast-container p-3 d-none\" data-bs-autohide=\"true\" data-bs-delay=\"5000\">\r\n    <div class=\"toast show\" role=\"alert\" aria-live=\"assertive\" aria-atomic=\"true\">\r\n      <div class=\"toast-header\">\r\n        <strong class=\"me-auto\"></strong>\r\n        <button type=\"button\" class=\"btn-close\" aria-label=\"Close\" ></button>\r\n      </div>\r\n      <div class=\"toast-body\"></div>\r\n    </div>\r\n  </div>\r\n</div>";

      // Render Counter component.
      var component = _testContext.RenderComponent<Login>();

      component.MarkupMatches(expectedMarkUp);
    }

    [Fact]
    public void Login_ButtonClick_Test()
    {
      var loginComponent = _testContext.RenderComponent<Login>();
      var loginBtn = loginComponent.Find("button");
      var navMgr = _testContext.Services.GetRequiredService<NavigationManager>();

      loginBtn.Click();
      loginBtn.Click(detail: 3, ctrlKey: true);
      loginBtn.Click(new MouseEventArgs());

      Assert.NotNull(loginBtn);
      Assert.Equal("http://localhost/", navMgr.Uri);
    }
  }
}