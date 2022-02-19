import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AniversarioListaComponent } from './aniversario-lista.component';

describe('AniversarioListaComponent', () => {
  let component: AniversarioListaComponent;
  let fixture: ComponentFixture<AniversarioListaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AniversarioListaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AniversarioListaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
