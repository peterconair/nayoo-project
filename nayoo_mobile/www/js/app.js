var page = 0;

function onLoad() {
    document.addEventListener("deviceready", onDeviceReady, false);
}

// device APIs are available
//
function onDeviceReady() {
    // Register the event listener
    document.addEventListener("backbutton", onBackKeyDown, false);
}

// Handle the back button
//
function onBackKeyDown() {
  switch(page)
  {
    case 0 :
      navigator.app.exitApp();
      break;
    case 1 :
      navigator.app.exitApp();
      break;
    case 2 :
      loginClick();
      break;
    default :
      navigator.app.exitApp();
      break;
  }
}

function loginClick() {
    page = 1;
    $( "#mainPage" ).load( "html/menu.html" );
}

function cardClick() {
    page = 2;
    $( "#mainPage" ).load( "html/card.html" );
  }
  
function feedClick() {
  var links = [
      {
          "bgcolor":"#64b5f6",
          "icon":"+"
      }
  ]
  $('.kc_fab_wrapper').kc_fab(links);
}