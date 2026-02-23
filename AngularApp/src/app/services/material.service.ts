import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Material, MaterialCreateDTO, MaterialUpdateDTO } from '../models/material';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class MaterialService {

  private urlBase = 'https://localhost:7006/api/Materials';

  constructor(private http: HttpClient) { }

  getMaterials() : Observable<Material[]> {
    return this.http.get<Material[]>(this.urlBase);
  }

  getMaterialById(id : number) : Observable<Material> {
    return this.http.get<Material>(this.urlBase + '/' + id);
  }

  createMaterial(material: MaterialCreateDTO) : Observable<Material>{
    console.log('service: ' + material);
    return this.http.post<Material>(this.urlBase, material);
  }

  updateMaterial(id: number, material: MaterialUpdateDTO) : Observable<Material>{
    return this.http.put<Material>(this.urlBase + '/' + id, material);
  }

  deleteMaterial(id : number) : Observable<void>{
    return this.http.delete<void>(this.urlBase + '/' + id);
  }
}
