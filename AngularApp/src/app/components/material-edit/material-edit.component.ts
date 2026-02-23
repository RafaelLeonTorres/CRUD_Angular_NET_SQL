import { Component, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MaterialUpdateDTO } from '../../models/material';
import { ActivatedRoute, Router } from '@angular/router';
import { MaterialService } from '../../services/material.service';

@Component({
  selector: 'app-material-edit',
  standalone: true,
  imports: [MatInputModule, MatButtonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './material-edit.component.html',
  styleUrl: './material-edit.component.css'
})
export class MaterialEditComponent implements OnInit {
  material: MaterialUpdateDTO = { name: '', description: '' };  
  id: number  = 0;
    constructor(
      private route: ActivatedRoute,
      private materialService: MaterialService,
      private router: Router
    ){}

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.materialService.getMaterialById(this.id).subscribe(data => {
      this.material = data;
    });
  }
  
    funcionMaterial() : void {
      if (this.id === 0){
        this.materialService.createMaterial(this.material).subscribe(() => {
          this.router.navigate(['/']);
        })
      }
      else{
        this.materialService.updateMaterial(this.id, this.material).subscribe(() => {
          this.router.navigate(['/']);
        })
      }    
    }
}
