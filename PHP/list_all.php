<?php

$userId='viaidea';
$uploaddir = './product/'.$userId.'/'; // Relative Upload Location of data file

if(!file_exists($uploaddir))
{
	mkdir($uploaddir);
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

// print 'em
print("<TABLE border=1 cellpadding=5 cellspacing=0 class=whitelinks>\n");
print("<TR><TH>No.</TH><TH>Filename</TH><th>Filetype</th><th>Bookcover</th></TR>\n");
// loop through the array of files and print them all
$pageIndex=1;
for($index=0; $index < $indexCount; $index++) 
{
	if (substr("$dirArray[$index]", 0, 1) != ".")
	{ 
		$filename = $dirArray[$index];
		$ext = pathinfo($filename, PATHINFO_EXTENSION);
		if(strcmp($ext, 'vip')==0 || strcmp($ext, 'vig')==0)
		{
			$fileurl='get_item.php?userId='.$userId.'&item='.$dirArray[$index];
			print("<TR><TD>$pageIndex</td>");
			// don't list hidden files
			print("<TD><a href=\"$fileurl\">$dirArray[$index]</a></td>");
			print("<td>");
			print($ext);
			print("</td>");
			print("<td><img src=\"");
			print($uploaddir.'/'.$dirArray[$index].'.jpg');
			print("\" /></td>");
			print("</TR>\n");
			$pageIndex++;
		}
	}
}
print("</TABLE>\n");



?>