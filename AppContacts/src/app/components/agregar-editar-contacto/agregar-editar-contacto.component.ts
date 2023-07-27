import { Component, OnInit } from '@angular/core';
import { FormBuilder,FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Contacto } from 'src/app/interfaces/contacto';
import { ContactoService } from 'src/app/services/contacto.service';

@Component({
  selector: 'app-agregar-editar-contacto',
  templateUrl: './agregar-editar-contacto.component.html',
  styleUrls: ['./agregar-editar-contacto.component.css']
})
export class AgregarEditarContactoComponent implements OnInit {

  loading:boolean=false;
  form:FormGroup;
  id:number;
  operacion:string = "Agregar";

  constructor(private fb:FormBuilder, private _contactosService:ContactoService, private _snackbar:MatSnackBar,
    private router:Router, private aRoute:ActivatedRoute){

    this.form = fb.group({
      firstName:['', Validators.required ],
      secondName:['', Validators.required ],
      dateBirth:['', Validators.required ],
      adresses:['', Validators.required ],
      phoneNumber:['', Validators.required ],
      image:['image.png']
    })

    this.id=Number(aRoute.snapshot.paramMap.get('id'));

  }

  onFileSelected(event: any) {
    const archivo = event.target.files[0];
    this.form.patchValue({
      imagen: archivo
    });
  }


  ngOnInit(): void {
    if (this.id != 0) {
      this.operacion="Editar";
      this.obtenerContacto(this.id);
    }
    
  }

  obtenerContacto(id:number){
    this.loading=true;
    this._contactosService.getContact(id).subscribe({
      next:(data)=>{
        this.form.patchValue({
          firstName: data.result.firstName,
          secondName: data.result.secondName,
          dateBirth: data.result.dateBirth,
          adresses: data.result.adresses,
          phoneNumber: data.result.phoneNumber,
          image: data.result.image,
        })
        this.loading=false;
      }
    })
  }


  agregarEditarContacto(){

    const contacto:Contacto = {
      firstName:this.form.value.firstName,
      secondName:this.form.value.secondName,
      dateBirth:this.form.value.dateBirth,
      adresses:this.form.value.adresses,
      phoneNumber:this.form.value.phoneNumber,
      image:this.form.value.image
      
    }

    if(this.id!=0){
      contacto.id=this.id;
       this.editarContacto(this.id,contacto)
    }else
    this.agregarContacto(contacto);

  }

  agregarContacto(contacto:Contacto){
    this._contactosService.addContact(contacto).subscribe({
      next:()=>{
        this.mensajeExito("Register successfully!!");
        this.router.navigate(['/listContacts']);
      },
      error:(e)=>{}
    })
  }

  editarContacto(id:number,contacto:Contacto){
    this._contactosService.updateContact(contacto).subscribe({
      next:(data)=>{
        this.mensajeExito("Updating successfully!!");
        this.router.navigate(['/listMascotas']);
      },
      error:(e)=>{}
    })
  }

  mensajeExito(text:string){
    this.loading=false;
    this._snackbar.open(text,'',{
      duration: 4000,
      horizontalPosition:'right'

    });
  }

}
