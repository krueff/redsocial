$(document).ready(function () {
	$("#hide").click(function () {
		$("#Lugar").hide();
		$("#Musico").slideDown();
		$("#show").css({ "color": "rgba(255,255,255,0.5)"});
		$("#hide").css({ "color": "rgba(255,255,255,1)" });
	});
	$("#show").click(function () {
		$("#Lugar").slideDown();
		$("#Musico").hide();
		$("#hide").css({ "color": "rgba(255,255,255,0.5)"});
		$("#show").css({ "color": "rgba(255,255,255,1)" });
	});
	$('#hide').css('cursor', 'pointer');
	$('#show').css('cursor', 'pointer');
});