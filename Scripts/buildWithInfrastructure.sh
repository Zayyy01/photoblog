inf_path="$1/PhotoblogInfrastructure/PhotoblogInfrastructure.csproj"
dotnet build $inf_path
copy_from="$1/PhotoblogInfrastructure/bin/$4/netcoreapp3.1/PhotoblogInfrastructure.dll"
copy_to="$1/Photoblog/bin/$4/netcoreapp3.1"
cp $copy_from $copy_to
path="$1/Photoblog/Photoblog.csproj"
dotnet build $path
