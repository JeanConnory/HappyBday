import { Component, Input, OnInit } from '@angular/core';
import { inject } from '@angular/core/testing';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrls: ['./titulo.component.scss']
})

export class TituloComponent implements OnInit {

  @Input() titulo: string = "";

  constructor() { }

  ngOnInit() {
  }

}
