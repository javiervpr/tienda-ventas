import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  MatToolbarModule,
  MatIconModule,
  MatButtonModule,
  MatTooltipModule,
  MatCardModule,
  MatTabsModule,
  MatDialogModule,
  MatTableModule,
  MatRippleModule
} from '@angular/material';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatTooltipModule,
    MatCardModule,
    MatTabsModule,
    MatDialogModule,
    MatTableModule,
    MatRippleModule
  ],
  exports: [
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatTooltipModule,
    MatCardModule,
    MatTabsModule,
    MatDialogModule,
    MatTableModule,
    MatRippleModule
  ]
})
export class SharedModule { }
