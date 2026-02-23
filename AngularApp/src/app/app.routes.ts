import { Routes } from '@angular/router';
import { MaterialListComponent } from './components/material-list/material-list.component';
import { MaterialEditComponent } from './components/material-edit/material-edit.component';
import { MaterialCreateComponent } from './components/material-create/material-create.component';

export const routes: Routes = [
    {path: '', component: MaterialListComponent},
    {path: 'edit/:id', component: MaterialEditComponent},
    {path: 'create', component: MaterialCreateComponent},
];
