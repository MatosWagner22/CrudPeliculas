import { Component, OnInit } from '@angular/core';
import { PeliculaService } from './services/pelicula.service';
import { Pelicula } from './models/pelicula.model';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  imports: [RouterModule],
  standalone: true,
})
export class AppComponent implements OnInit {
  title = 'My Angular App';
  peliculas!: Pelicula[];

  constructor(private peliculaService: PeliculaService) { }

  ngOnInit() {
    this.peliculaService.getPeliculas().subscribe(data => {
      this.peliculas = data;
    });
  }
}
