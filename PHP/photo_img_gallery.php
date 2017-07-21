<html>
	<head>
		<meta http-equiv="Content-type" content="text/html; charset=utf-8">
		<title>Non Photo-Realistic Rendering Application Web Portal: Uploaded Photo</title>
		<link rel="stylesheet" href="css/basic.css" type="text/css" />
		<link rel="stylesheet" href="css/galleriffic-3.css" type="text/css" />
		<script type="text/javascript" src="js/jquery-1.3.2.js"></script>
		<script type="text/javascript" src="js/jquery.history.js"></script>
		<script type="text/javascript" src="js/jquery.galleriffic.js"></script>
		<script type="text/javascript" src="js/jquery.opacityrollover.js"></script>
		<!-- We only want the thunbnails to display when javascript is disabled -->
		<script type="text/javascript">
			document.write('<style>.noscript { display: none; }</style>');
		</script>
	</head>
	<body>
		<div id="page">
			<div>
			<table width="100%" border="1">
			<tr>
			<td align="center" width="33%"><a href="img_gallery.php">Home</a></td>
			<td align="center" width="33%"><a href="art_img_gallery.php">Art Gallery Portal</a></td>
			<td align="center" width="33%">Photo Gallery Portal</td>
			</tr>
			</table>
			</div>
			<div id="container">
				<h1><a href="index.php">NPRender -- Uploaded Photos</a></h1>
				<h2>Web Portal for Uploaded Photos</h2>

				<!-- Start Advanced Gallery Html Containers -->
				<div id="gallery" class="content">
					<div id="controls" class="controls"></div>
					<div class="slideshow-container">
						<div id="loading" class="loader"></div>
						<div id="slideshow" class="slideshow"></div>
					</div>
					<div id="caption" class="caption-container"></div>
				</div>
				<div id="thumbs" class="navigation">
					<ul class="thumbs noscript">
					
<?php
$uploaddir = './images/'; // Relative Upload Location of data file
$thumbdir='./image_thumbs/';

if(!file_exists($uploaddir))
{
	mkdir($uploaddir);
}

if(!file_exists($thumbdir))
{
	mkdir($thumbdir);
}

$myDirectory = opendir($uploaddir);

// get each entry
while($entryName = readdir($myDirectory)) 
{
	$dirArray[] = $entryName;
}

// close directory
closedir($myDirectory);

//	count elements in array
$indexCount	= count($dirArray);


// sort 'em
sort($dirArray);

// loop through the array of files and print them all
$pageIndex=1;
for($index=0; $index < $indexCount; $index++) 
{
	if (substr("$dirArray[$index]", 0, 1) != ".")
	{ 
		$filename = $dirArray[$index];
		$ext = pathinfo($filename, PATHINFO_EXTENSION);
		if(strcmp($ext, 'jpg')==0)
		{
			$fileurl=$uploaddir.$dirArray[$index];
			$thumburl=$thumbdir.$dirArray[$index];
			
			print("<li>");
			print('<a class="thumb" name="leaf" href="create_photo_thumbnail.php?img='.$filename.'&mw=320&mh=480" title="Img #'.$pageIndex.'">');
			print('<img src="create_photo_thumbnail.php?img='.$filename.'&mw=80&mh=120" alt="Img #'.$pageIndex.'" />');
			print('</a>');
			print('<div class="caption">');
			print('<div class="download">');
			print('<a href="'.$fileurl.'">Download Original</a>');
			print('</div>');
			print('<div class="image-title">Img #'.$pageIndex.'</div>');
			print('<div class="image-desc">'.$filename.'</div>');
			print('</div>');
			print('</li>');
			$pageIndex++;
		}
	}
}
?>
						

						
					</ul>
				</div>
				<!-- End Advanced Gallery Html Containers -->
				<div style="clear: both;"></div>
			</div>
		</div>
		<div id="footer">&copy; 2012 NPRender</div>
		<script type="text/javascript">
			jQuery(document).ready(function($) {
				// We only want these styles applied when javascript is enabled
				$('div.navigation').css({'width' : '300px', 'float' : 'left'});
				$('div.content').css('display', 'block');

				// Initially set opacity on thumbs and add
				// additional styling for hover effect on thumbs
				var onMouseOutOpacity = 0.67;
				$('#thumbs ul.thumbs li').opacityrollover({
					mouseOutOpacity:   onMouseOutOpacity,
					mouseOverOpacity:  1.0,
					fadeSpeed:         'fast',
					exemptionSelector: '.selected'
				});
				
				// Initialize Advanced Galleriffic Gallery
				var gallery = $('#thumbs').galleriffic({
					delay:                     2500,
					numThumbs:                 15,
					preloadAhead:              10,
					enableTopPager:            true,
					enableBottomPager:         true,
					maxPagesToShow:            7,
					imageContainerSel:         '#slideshow',
					controlsContainerSel:      '#controls',
					captionContainerSel:       '#caption',
					loadingContainerSel:       '#loading',
					renderSSControls:          true,
					renderNavControls:         true,
					playLinkText:              'Play Slideshow',
					pauseLinkText:             'Pause Slideshow',
					prevLinkText:              '&lsaquo; Previous Photo',
					nextLinkText:              'Next Photo &rsaquo;',
					nextPageLinkText:          'Next &rsaquo;',
					prevPageLinkText:          '&lsaquo; Prev',
					enableHistory:             true,
					autoStart:                 false,
					syncTransitions:           true,
					defaultTransitionDuration: 900,
					onSlideChange:             function(prevIndex, nextIndex) {
						// 'this' refers to the gallery, which is an extension of $('#thumbs')
						this.find('ul.thumbs').children()
							.eq(prevIndex).fadeTo('fast', onMouseOutOpacity).end()
							.eq(nextIndex).fadeTo('fast', 1.0);
					},
					onPageTransitionOut:       function(callback) {
						this.fadeTo('fast', 0.0, callback);
					},
					onPageTransitionIn:        function() {
						this.fadeTo('fast', 1.0);
					}
				});

				/**** Functions to support integration of galleriffic with the jquery.history plugin ****/

				// PageLoad function
				// This function is called when:
				// 1. after calling $.historyInit();
				// 2. after calling $.historyLoad();
				// 3. after pushing "Go Back" button of a browser
				function pageload(hash) {
					// alert("pageload: " + hash);
					// hash doesn't contain the first # character.
					if(hash) {
						$.galleriffic.gotoImage(hash);
					} else {
						gallery.gotoIndex(0);
					}
				}

				// Initialize history plugin.
				// The callback is called at once by present location.hash. 
				$.historyInit(pageload, "advanced.html");

				// set onlick event for buttons using the jQuery 1.3 live method
				$("a[rel='history']").live('click', function(e) {
					if (e.button != 0) return true;
					
					var hash = this.href;
					hash = hash.replace(/^.*#/, '');

					// moves to a new page. 
					// pageload is called at once. 
					// hash don't contain "#", "?"
					$.historyLoad(hash);

					return false;
				});

				/****************************************************************************************/
			});
		</script>
	</body>
</html>