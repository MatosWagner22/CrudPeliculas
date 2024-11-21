export interface Pelicula {
  id: number;
  titulo: string;
  director: string;
  descripcion?: string;
  esEstreno: boolean;
  genero: string;
  esAnimada: boolean;
  fechaEstreno: Date;
  urlVideo: string;
}
