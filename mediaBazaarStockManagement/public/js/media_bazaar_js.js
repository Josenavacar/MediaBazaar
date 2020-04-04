// When page is loaded
// check the URL
// if its login or home then hide side menu
// else if not login page...hide the login button
$( document ).ready(function() {
  if(($(location).attr('href') == "http://localhost/projs/mediabazaar/mediaBazaarStockManagement/") || 
  	($(location).attr('href') == "http://localhost/projs/mediabazaar/mediaBazaarStockManagement/login"))
  {
  	$("#sidebar-wrapper").hide();
  	$("#menu-toggle").hide();
  }
  else if($(location).attr('href') != "http://localhost/projs/mediabazaar/mediaBazaarStockManagement/login")
  {
    $(".loginbutton").hide();
  }
});

// Toggle menu button
$("#menu-toggle").click(function(e) 
	{
		e.preventDefault();
		$("#wrapper").toggleClass("toggled");
	}
);