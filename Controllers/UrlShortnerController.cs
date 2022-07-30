using Microsoft.AspNetCore.Mvc;


namespace aerospike.Controllers;

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
     
        (string token,string shortURL) = _shortner.GetShortUrl(req.Url);
        return new Response(){
            ShortUrl = shortURL,
            Token = token
        };    
        
        
        
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
