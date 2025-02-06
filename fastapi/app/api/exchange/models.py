from uuid import UUID

from sqlalchemy import ForeignKey
from sqlalchemy.orm import Mapped, mapped_column, relationship

from app.database import Base
from app.api.exchange.constants import ExchangeType
from app.api.member.models import Member

class Exchange(Base):
    __tablename__ = 'cultural_exchanges'
  
    id: Mapped[UUID] = mapped_column(primary_key=True)
    
    year: Mapped[int]
    exchange_type: Mapped[ExchangeType]
    
    member_id: Mapped[UUID] = mapped_column(ForeignKey('members.id'))
    member: Mapped[Member] = relationship(Member, back_populates='children')