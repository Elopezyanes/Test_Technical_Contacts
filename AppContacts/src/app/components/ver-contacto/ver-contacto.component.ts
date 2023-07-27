import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Contacto } from 'src/app/interfaces/contacto';
import { ContactoService } from 'src/app/services/contacto.service';

@Component({
  selector: 'app-ver-contacto',
  templateUrl: './ver-contacto.component.html',
  styleUrls: ['./ver-contacto.component.css']
})
export class VerContactoComponent implements OnInit {

  id:number;
  contact!:Contacto;
  loading:boolean = false;

  constructor(private _contactoService:ContactoService, private route:ActivatedRoute){
    this.id=+route.snapshot.paramMap.get('id')!;

}

  ngOnInit(): void {
    this.obtenerContacto();
  }

  obtenerContacto(){
    this.loading=true;
    this._contactoService.getContact(this.id).subscribe({
      next:(data)=>{
        this.loading=false;
            this.contact=data.result;
            console.log(this.contact);
      }
    })
  }
}
