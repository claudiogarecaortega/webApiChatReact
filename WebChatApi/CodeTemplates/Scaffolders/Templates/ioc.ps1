[T4Scaffolding.Scaffolder(Description = "Enter a description of ABMController here")][CmdletBinding()]
param(   
	[parameter(Mandatory = $false)][string]$Model,
    [string]$Project,
	[string]$CodeLanguage = "cs",
	[switch]$Force = $false,
	[string]$ForceMode,
	[parameter(Mandatory = $false)][string]$CarpetaDominio,
	[parameter(Mandatory = $false)][string]$Tabla,
	[parameter(Mandatory = $false)][string]$Key,
	[switch]$NoChildItems = $false,
	[string[]]$TemplateFolders
)
$items = Get-ChildItem -Path "D:\SistemaIntegradoFerias\Dominio\SistemaStock"
foreach ($item in $items)
{

      # if the item is a directory, then process it.
      if ($item.Attributes -eq "Directory")
      {
           # Write-Host  "$("C:\Users\garecaor\Documents\Beta\trunk\Dominio\")$($item.Name) "
			if($item.Name -ne "bin" -and $item.Name -ne "obj" -and $item.Name -ne "Properties" -and $item.Name -and "AttachmentDominio" -and $item.Name -ne "IdentificableObject" -and $item.Name -ne "Properties" )
			{
           
			$files = Get-ChildItem -Path  "$("D:\SistemaIntegradoFerias\Dominio\SistemaStock\")$($item.Name) "
			
				#foreach ($file in $files)
				#{
				
				#		if ($file.Attributes -ne "Directory" )
				#		{
				#		 $CarpetaDominio="$($CarpetaDominio)$($item.Name)"
				#		 	$s="$($s)$($file.Name)"
				#			$Model=$s.Substring(0, $s.IndexOf('.'))

				#					$dao= "For<I"+$Model+"Dao>().Use<"+$Model+"Dao>();" 
				#			Write-Host $dao
				#					$CarpetaDominio=""
				#					$s=""
				#					$Model=""
				#				}
								 
							
				#		}
				foreach ($file in $files)
				{
					
						if ($file.Attributes -ne "Directory" )
						{
						 $CarpetaDominio="$($CarpetaDominio)$($item.Name)"
						 	$s="$($s)$($file.Name)"
							$Model=$s.Substring(0, $s.IndexOf('.'))

							#$mapper= "modelBuilder.Configurations.Add(new "+$Model+"Map());"
							#$mapper=" public DbSet<"+$Model+"> "+$Model+"s { get; set; }"
							$dao= "For<I"+$Model+"ViewModelMapper>().Use<"+$Model+"ViewModelMapper>();" 
							Write-Host $mapper
									$CarpetaDominio=""
									$s=""
									$Model=""
								}
								 
							
						}
				
			}
      }
}
