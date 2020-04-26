// When page is loaded
// check the URL
// if its login or home then hide side menu
// else if not login page...hide the login button
$( document ).ready(function() 
{
  let pathArray = window.location.pathname.split('/');

  if((pathArray[2] + "/" + pathArray[3] == "mediaBazaarStockManagement/login") || 
  	("/" + pathArray[1] + "/" + pathArray[2] + "/" == $(location).attr('pathname')))
  {
  	$("#sidebar-wrapper").hide();
  	$("#menu-toggle").hide();
  }
  else if(pathArray[2] + "/" + pathArray[3] != "mediaBazaarStockManagement/login")
  {
    $(".loginbutton").hide();
  }

  let param = window.location.pathname.split("/").pop();

  //if((param == "1") || (param == "2"))
  if(param != "0")
  {
    $("#backButton").show();
  }
  else
  {
    $("#backButton").hide();
  }
});

// Toggle menu button
$("#menu-toggle").click(function(e) 
	{
		e.preventDefault();
		$("#wrapper").toggleClass("toggled");
	}
);