import axios from "axios";
import { useEffect, useState } from "react";
import MovieCard from "./MovieCard";
function Movie() {
	const apiUrl = "https://www.omdbapi.com/?i=tt3896198&apikey=1c12799f&s=titanic&page=1"
	const [movieData, setMovieData] = useState([]);
	const getMovieData = async() => {
		try {
			const response = await axios.get(apiUrl);
			console.log(response.data.Search);
			setMovieData(response.data.Search); // update the state with movie data from api.
		}
		catch (error) {
			console.error("Error while loading the data ", error);
		}
		finally {
			console.log("Exiting......");
		}
	}
	useEffect(() => {
		getMovieData();
	}, []);
 
	return (
<div>
<h3> Movies Information </h3>
<ul style={{display:"grid" , gridTemplateColumns:"repeat(4, 1fr)", gap: "20px", listStyle:"none" , padding: 0}}>
				{ movieData ? (movieData.map((movie) =>
					/*<li key={movie.imdbID}>{movie.Title}  | {movie.Year}</li>*/
<MovieCard key={movie.imdbID} movieData={ movie}></MovieCard>
				)
				) : <p> No Movie data found...</p>
				}
</ul>
</div>
)}
 
export default Movie