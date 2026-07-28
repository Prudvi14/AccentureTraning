export default function MovieCard({movieData})
{
	const { imdbID, Title, Year, Poster } = movieData; // Desctructuring concept
 
	return (
<div>
 
			<img height={200} width={150}
				src={ Poster !== "N/A" ? Poster : "no-image"} alt="{Title}"></img>
<h3>{Title}</h3>
<p> Year : { Year}</p>
</div>
	)
 
}