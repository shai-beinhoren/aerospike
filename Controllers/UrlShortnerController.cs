using Microsoft.AspNetCore.Mvc;


namespace aspdockerapi.Controllers;

[ApiController]
[Route("[controller]")]
public class UrlShortnerController : ControllerBase
{
   
    private Shortener _shortner;
    public UrlShortnerController()
    {

        _shortner = new Shortener();
    }
    public class PostReq{
        public string Url { get; set; }
    }

    public class Response{
        public string ShortUrl { get; set; }
        public string Token { get; set; }
    }



    [HttpPost, Route("/api/shorten")]
    public Response  PostURL([FromBody] PostReq  req) {
        try{
            (string token,string shortURL) = _shortner.GetShortUrl(req.Url);
        return new Response(){
            ShortUrl = shortURL,
            Token = token
        };    
        }
        catch(Exception e)
        {
             return new Response(){
            ShortUrl = e.Message,
            Token = e.StackTrace
        };    
        }
        
        
    }

    [HttpGet, Route("/{token}")]
    public IActionResult UrlRedirect([FromRoute] string token) {
        try{
            string url = _shortner.GetUrl(token);
            return Redirect(
                url
            );
        }
        catch(Exception e){

            return NotFound();
        }
        
    }

   



    
}
