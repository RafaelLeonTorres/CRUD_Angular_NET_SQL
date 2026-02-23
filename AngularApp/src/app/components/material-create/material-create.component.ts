import { Component } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MaterialCreateDTO } from '../../models/material';
import { MaterialService } from '../../services/material.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-material-create',
  standalone: true,
  imports: [MatInputModule, MatButtonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './material-create.component.html',
  styleUrl: './material-create.component.css'
})
export class MaterialCreateComponent {
  material: MaterialCreateDTO = { name: '', description: '' };  

  constructor(
    private materialService: MaterialService,
    private router: Router
  ){}

  createMaterial() : void {
    this.materialService.createMaterial(this.material).subscribe(() => {
      this.router.navigate(['/']);
    })
  }
}
