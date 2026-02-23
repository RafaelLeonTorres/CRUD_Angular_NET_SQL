import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { Material } from '../../models/material';
import { MaterialService } from '../../services/material.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-material-list',
  standalone: true,
  imports: [MatButtonModule, MatTableModule, MatIconModule],
  templateUrl: './material-list.component.html',
  styleUrl: './material-list.component.css'
})
export class MaterialListComponent  implements OnInit{

  materials: Material[] = [];

  ngOnInit(): void {
    this.loadMaterials();
  }

  constructor(
    private materialService: MaterialService,
    public router : Router
  ) {}

  loadMaterials() : void{
    this.materialService.getMaterials().subscribe({
      next: (data) => {
        this.materials = data;
        console.log('Datos cargados:', this.materials); // <-- Aquí se ven los datos
      },
      error: (err) => {
        console.error('Error al cargar materiales:', err); // Manejo de errores
      }
    });
  }

  deleteMaterial(id: number) : void {
    this.materialService.deleteMaterial(id).subscribe(() => {
      this.loadMaterials();
    })
  }

  editMaterial(id: number){
    this.router.navigate(['/edit', id]);
  }
}
