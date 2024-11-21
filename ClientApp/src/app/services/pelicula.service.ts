import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Pelicula } from '../models/pelicula.model'; // Ajusta la ruta según la estructura de carpetas

@Injectable({
  providedIn: 'root'
})
export class PeliculaService {
  private apiUrl = 'https://localhost:7284/api/peliculas';

  constructor(private http: HttpClient) { }

  getPeliculas(): Observable<Pelicula[]> {
    return this.http.get<Pelicula[]>(this.apiUrl);
  }

  getPelicula(id: number): Observable<Pelicula> {
    return this.http.get<Pelicula>(`${this.apiUrl}/${id}`);
  }

  createPelicula(pelicula: Pelicula): Observable<Pelicula> {
    return this.http.post<Pelicula>(this.apiUrl, pelicula);
  }

  updatePelicula(id: number, pelicula: Pelicula): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, pelicula);
  }

  deletePelicula(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
